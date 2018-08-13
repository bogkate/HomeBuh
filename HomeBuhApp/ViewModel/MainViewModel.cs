using GalaSoft.MvvmLight;

namespace HomeBuhApp.ViewModel
{
    using System;
    using System.Configuration;
    using System.Linq;
    using GalaSoft.MvvmLight.CommandWpf;
    using HomeBuhDb;
    using Model;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public PaymentsModel Model { get; private set; }

        public RelayCommand SaveCommand { get; private set; }
        public MainViewModel()
        {
            var now = DateTime.Now;
            Model = new PaymentsModel
            {
                DateStart = new DateTime(now.Year,now.Month,1),
                DateEnd = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1),
            };

            GetPayments();

            SaveCommand = new RelayCommand(OnSave);
        }

        private void OnSave()
        {
            try
            {
                using (var db = new Storage())
                {
                    foreach (var payment in Model.Payments)
                    {
                        
                        if (!string.IsNullOrEmpty(payment.ProductName))
                        {
                            if (!string.IsNullOrEmpty(payment.CategoryName))
                            {
                                var categoryDb = db.Categories.FirstOrDefault(s => s.Name == payment.CategoryName);
                                if (categoryDb == null)
                                {
                                    categoryDb = db.Categories.Add(new Category
                                    {
                                        Name = payment.CategoryName,
                                    });
                                }

                                var productDb = db.Products.FirstOrDefault(s => s.Name == payment.ProductName && s.Category.Name == payment.CategoryName);
                                if (productDb == null)
                                {
                                    productDb = db.Products.Add(new Product
                                    {
                                        Name = payment.ProductName,
                                        Category = categoryDb
                                    });
                                }

                                Payment paymentDb;
                                if (payment.PaymentId == 0)
                                {
                                    paymentDb = db.Payments.Add(new Payment());
                                }
                                else
                                {
                                    paymentDb = db.Payments.FirstOrDefault(s => s.PaymentId == payment.PaymentId);
                                    if (paymentDb == null)
                                    {
                                        continue;
                                    }
                                }

                                paymentDb.Product = productDb;
                                paymentDb.Date = payment.Date;
                                paymentDb.PaymentType = PaymentType.Credit;
                                paymentDb.Sum = payment.Sum;

                                db.SaveChanges();
                            }
                      
                        }
                    }
                }
            }
            catch (Exception exception)
            {

            }
            GetPayments();
        }

        private void GetPayments()
        {
            try
            {
                Model.Payments.Clear();
                using (var db = new Storage())
                {
                    foreach (var payment in db.Payments.ToList())
                    {
                        Model.Payments.Add(new PaymentModel
                        {
                            CategoryName = payment.Product.Category.Name,
                            ProductName = payment.Product.Name,
                            Date = payment.Date,
                            Sum = payment.Sum,
                            PaymentId = payment.PaymentId,
                        });
                    }
                }
            }
            catch (Exception exception)
            {

            }
        }
    }
}