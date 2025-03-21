using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Method_Design_Pattern
{
    internal class WeatherStation
    {
        public List<IObserver> observers = new List<IObserver>();

        public string currentUpdate;

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(currentUpdate);
            }
        }

        public void SetWeather(string newUpdate)
        {
            currentUpdate = newUpdate;
            NotifyObservers();
        }


    }
}
