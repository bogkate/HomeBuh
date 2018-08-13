using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuhApp.Model
{
    using GalaSoft.MvvmLight;
    public class PaymentModel:ObservableObject
    {
        private long paymentId;
        public long PaymentId
        {
            get=>paymentId;
            set
            {
                paymentId = value;
                RaisePropertyChanged(() => PaymentId);
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get=>date;
            set
            {
                date = value;
                RaisePropertyChanged(() => Date);
            }
        }

        private string categoryName;
        public string CategoryName
        {
            get=>categoryName;
            set
            {
                categoryName = value;
                RaisePropertyChanged(() => CategoryName);
            }
        }

        private string productName;
        public string ProductName
        {
            get=>productName;
            set
            {
                productName = value;
                RaisePropertyChanged(() => ProductName);
            }
        }

        private decimal sum;
        public decimal Sum
        {
            get=>sum;
            set
            {
                sum = value;
                RaisePropertyChanged(() => Sum);
            }
        }
    }
}
