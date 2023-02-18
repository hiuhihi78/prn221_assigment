using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Navigation
{
    public static class NavigationParameters 
    {
		private static Dictionary<string,object> parameters = new Dictionary<string, object>();

		public static Dictionary<string,object> Parameters
        {
			get { return parameters; }
			set { parameters = value; }
		}

	}
}
