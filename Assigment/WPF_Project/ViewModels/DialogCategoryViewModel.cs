using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Project.Command;
using WPF_Project.Services;
using WPF_Project.Views;
using WPF_Project.Models;

namespace WPF_Project.ViewModels
{
    class DialogCategoryViewModel : INotifyPropertyChanged
    {
        #region Declare varible
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(); }
        }

        #endregion

        private CategoryService categoryService;
        private DialogCategorys _dialogCategorys;
        private object _viewModelParentScreen;

        public DialogCategoryViewModel(DialogCategorys dialogCategorys, object viewModelParentScreen)
        {
            _dialogCategorys= dialogCategorys;
            _viewModelParentScreen= viewModelParentScreen;
            categoryService = new CategoryService();
            saveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        #region Save

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        public void ExecuteSaveCommand()
        {
            if (string.IsNullOrEmpty(Category))
            {
                MessageBox.Show("This Category's name must be not empty!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }else if(categoryService.GetCategoryByName(Category) != null) 
            {
                MessageBox.Show("This Category's name was existed!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Models.Category category = new Models.Category() { Name = Category};
                categoryService.CreateCategory(category);
                MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                ((DialogProductsViewModel)_viewModelParentScreen).LoadAllCategorys();
                ((DialogProductsViewModel)_viewModelParentScreen).SetDefaultCategory();
                _dialogCategorys.Close();
            }
        }
        #endregion

    }
}
