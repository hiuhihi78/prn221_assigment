using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class ImportDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(); }
        }

        private DateTime importDate;
        public DateTime ImportDate
        {
            get { return importDate; }
            set { importDate = value; NotifyPropertyChanged(); }
        }

        private int staffId;
        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; NotifyPropertyChanged(); }
        }

        private double? totalAmount;
        public double? TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; NotifyPropertyChanged(); }
        }

        private int supplierId;
        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; NotifyPropertyChanged(); }
        }

        private Staff staff;
        public Staff Staff
        {
            get { return staff; }
            set { staff = value; NotifyPropertyChanged(); }
        }

        private Supplier supplier;
        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; NotifyPropertyChanged(); }
        }

        public static ImportDTO FromImport(Import import) 
        {
            return new ImportDTO()
            {
                importDate = import.ImportDate,
                id = import.Id,
                staff = import.Staff,
                supplierId = import.SupplierId,
                staffId = import.StaffId,
                supplier = import.Supplier,
                totalAmount = import.TotalAmount,
                canCancel = DateTime.Now.Date.Subtract(import.ImportDate.Date).Days < 1,
            };
        }

        private bool? canCancel;

        public bool? CanCancel
        {
            get { return canCancel; }
            set { canCancel = value; NotifyPropertyChanged(); }
        }
    }
}
