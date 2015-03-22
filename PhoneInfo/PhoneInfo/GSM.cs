
namespace PhoneInfo
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        public Battery battery;
        public Display display;

        private static GSM IPhone = new GSM("IPhone5C", "Apple In.");


        private static List<Call> callHistory = new List<Call>();


        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null)
        {

        }
        public GSM(string model, string manufacturer, decimal? price, string owner)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.battery = new Battery();
            this.display = new Display();
        }
        public List<Call> CallHistory
        {
            get { return callHistory; }
        }

        public GSM IPhone4S
        {
            get { return IPhone; }
        }

        

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArithmeticException("Ivalid price");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            private set { this.owner = value; }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The manufacturer of the mobile phone can not be null");
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model of the mobile phone can not be null");
                }
                this.model = value;
            }
        }

        
        public void AddCallInHistory(Call newCall)
        {
            callHistory.Add(newCall);
        }

        public bool DeleteCallFromHistory(Call currentCall)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (callHistory[i].DateOfCall == currentCall.DateOfCall
                    && callHistory[i].TimeOfCall == currentCall.TimeOfCall
                    && callHistory[i].Duration == currentCall.Duration
                    && callHistory[i].DialedNumber == currentCall.DialedNumber)
                {
                    callHistory.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void ClearHistory()
        {
            callHistory.Clear();
        }

        

        public decimal CallPrice(decimal callPricePerMinute)
        {
            decimal sum = 0;
            foreach (var item in callHistory)
            {
                sum += (decimal)item.Duration / 60;
            }
            return sum;
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Model: " + this.model);
            result.AppendLine("Manufacturer: " + this.manufacturer);
            result.AppendLine(string.Format(new System.Globalization.CultureInfo("en-US"), "Price: {0:C}", this.price));
            result.AppendLine("Owner: " + this.owner);
            result.AppendLine("Battery model: " + this.battery.BatteryModel);
            result.AppendLine("Battery type: " + this.battery.TypeOfBattery);
            result.AppendLine("Talk hours: " + this.battery.BatteryHoursTalk);
            result.AppendLine("IDLE hours: " + this.battery.BatteryHoursTalk);
            result.AppendLine("Display size: " + this.display.Size);
            result.AppendLine("Number of colors: " + this.display.Colors);

            return result.ToString();
        }

    }
}
