using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                double sum = 0;
                foreach (var component in Components)
                {
                    sum += component.OverallPerformance;
                }
                double avgSum = Components.Count == 0 ? 0 : sum / Components.Count;

                return base.OverallPerformance + avgSum;
            }           
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = 0, peripheralsPrice = 0;

                foreach (var component in Components)
                {
                    componentsPrice += component.Price;
                }
                foreach (var peripheral in Peripherals)
                {
                    peripheralsPrice += peripheral.Price;
                }

                return base.Price + componentsPrice + peripheralsPrice;
            }            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format(" " + SuccessMessages.ComputerComponentsToString, Components.Count));
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString,
                Peripherals.Count, CalculatePeripheralsAveragePerformance()));

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (components.Where(c => c.GetType() == component.GetType()).Count() > 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, GetType().Name, Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Where(c => c.GetType().Name == componentType).Count() == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                   componentType, GetType().Name, Id));
            }

            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);
            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return peripheral;
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        private double CalculatePeripheralsAveragePerformance()
        {
            double peripheralsSum = 0;

            foreach (var peripheral in peripherals)
            {
                peripheralsSum += peripheral.OverallPerformance;
            }

            return peripherals.Count == 0 ? 0 : peripheralsSum / peripherals.Count;
        }
    }
}
