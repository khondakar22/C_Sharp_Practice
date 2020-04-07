using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    /// <summary>

    /// The 'Subject' abstract class

    /// </summary>
    internal abstract class Stock

    {
        private readonly string _symbol;
        private double _price;
        private readonly List<IInvestor> _investors = new List<IInvestor>();
 
        // Constructor

        public Stock(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;
        }
 
        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }
 
        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }
 
        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }
 
            Console.WriteLine("");
        }
 
        // Gets or sets the price

        public double Price
        {
            get { return _price; }
            set

            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
 
        // Gets the symbol

        public string Symbol
        {
            get { return _symbol; }
        }
    }
}