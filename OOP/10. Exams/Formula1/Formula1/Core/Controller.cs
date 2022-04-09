using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.FormulaOneCars;
using Formula1.Models.Pilots;
using Formula1.Models.Races;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            var car = formulaOneCarRepository.FindByName(carModel);

            if(car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            formulaOneCarRepository.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        //might try race.Pilots.Any(x => x.FullName == pilotFullName) instead of race.Pilots.Contains(pilot)
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            var pilot = pilotRepository.FindByName(pilotFullName);

            if(pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;
            if(type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            formulaOneCarRepository.Add(car);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if(pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepository.Add(new Pilot(fullName));

            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(m => m.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var executedRaces = raceRepository.Models.Where(m => m.TookPlace);

            var sb = new StringBuilder();
            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if(race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            var pilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToArray();
            pilots[0].WinRace();

            var sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, pilots[0].FullName, raceName));
            sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, pilots[1].FullName, raceName));
            sb.AppendLine(String.Format(OutputMessages.PilotThirdPlace, pilots[2].FullName, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
