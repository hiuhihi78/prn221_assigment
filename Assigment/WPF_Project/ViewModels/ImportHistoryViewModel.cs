using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class ImportHistoryViewModel : INotifyPropertyChanged
    {
        #region Declare Varible
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged(); SearchImport(); }
        }

        private DateTime endDate = DateTime.Now;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged(); SearchImport(); }
        }

        private DateTime _currentDate = DateTime.Now;

        private string searchImportInfo;

        public string SearchImportInfo
        {
            get { return searchImportInfo; }
            set { searchImportInfo = value; OnPropertyChanged(); SearchImport(); }
        }


        private ObservableCollection<ImportDTO> imports;

        public ObservableCollection<ImportDTO> Imports
        {
            get { return imports; }
            set { imports = value; OnPropertyChanged(); }
        }

        #endregion

        private ImportService importService = new ImportService();
        public ImportHistoryViewModel()
        {
            imports = new ObservableCollection<ImportDTO>();
            searchImportInfo = string.Empty;
            SearchImport();
            viewImportDetail = new RelayCommand<ImportDTO>(ExecuteViewImportDetail, o => true);
        }

        #region Search order
        private void SearchImport()
        {
            Imports = importService.GetImportsByCondition(SearchImportInfo, StartDate, EndDate);
        }
        #endregion

        #region View order details

        private RelayCommand<ImportDTO> viewImportDetail;

        public RelayCommand<ImportDTO> ViewImportDetail
        {
            get { return viewImportDetail; }
            set { viewImportDetail = value; }
        }

        private void ExecuteViewImportDetail(ImportDTO import)
        {
            DialogImportDetail dialogImportDetail = new DialogImportDetail();
            dialogImportDetail.DataContext = new DialogImportViewModel(dialogImportDetail, this, import);
            dialogImportDetail.ShowDialog();    
        }

        #endregion


    }
}
