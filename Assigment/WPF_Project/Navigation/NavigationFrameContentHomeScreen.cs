using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Project.Navigation
{
    public static class NavigationFrameContentHomeScreen
    {
        private static Frame _frame;

        public static void Initialize(Frame frame)
        {
            _frame = frame;
        }

        public static void NavigateTo(Page? page)
        {
            _frame.Navigate(page);
        }

        public static void NavigateTo(Page page, object dataContext)
        {
            page.DataContext = dataContext;
            _frame.Navigate(page);
        }


        public static void GoBack()
        {
            _frame.GoBack();
        }
    }
}
