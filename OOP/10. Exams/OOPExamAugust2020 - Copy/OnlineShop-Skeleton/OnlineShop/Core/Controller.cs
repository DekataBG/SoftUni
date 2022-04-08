using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, 
            string model, decimal price, double overallPerformance, int generation)
        {
            var computer = ComputerExists(computerId);

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == componentType);


            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent component = Activator.CreateInstance(type, id, manufacturer,
                        model, price, overallPerformance, generation) as IComponent;

            computer.AddComponent(component);
            components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, component.Id, computerId);
        }

        //
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            this.computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        //
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, 
            string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheralToAdd = null;
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheralToAdd = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheralToAdd = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheralToAdd = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheralToAdd = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(peripheralToAdd);
            this.peripherals.Add(peripheralToAdd);


            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var orderedComputers = computers
                .Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance)
                .ToArray();

            if(orderedComputers.Count() == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var computerToRemove = orderedComputers[0];
            computers.Remove(computerToRemove);

            return computerToRemove.ToString();
        }

        public string BuyComputer(int id)
        {
            var computer = ComputerExists(id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = ComputerExists(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = ComputerExists(computerId);
            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            if(component == null)
            {
                return String.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId);
            }

            computer.RemoveComponent(componentType);

            components.Remove(component);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = ComputerExists(computerId);
            var peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if(peripheral == null)
            {
                return String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId);
            }

            computer.RemovePeripheral(peripheralType);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private IComputer ComputerExists(int computerId)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);

            if(computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }
    }
}
