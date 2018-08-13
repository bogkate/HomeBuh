using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuhApp.Model
{
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;

    public class PaymentsModel : ObservableObject
    {
        private DateTime dateStart;

        public DateTime DateStart
        {
            get => dateStart;
            set
            {
                dateStart = value;
                RaisePropertyChanged(() => DateStart);
            }
        }

        private DateTime dateEnd;

        public DateTime DateEnd
        {
            get => dateEnd;
            set
            {
                dateEnd = value;
                RaisePropertyChanged(() => DateEnd);
            }
        }

        private ObservableCollection<PaymentModel> payments;
        public ObservableCollection<PaymentModel> Payments
        {
            get=>payments;
            set
            {
                payments = value;
                RaisePropertyChanged(() => Payments);
            }
        }

        public PaymentsModel()
        {
            Payments = new ObservableCollection<PaymentModel>();
        }
    }
}
