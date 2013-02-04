using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackMesa.PreferenceManagement.Controllers
{
    public class TrayItemController
    {
        private static object _instanceLock = new object();
        private static TrayItemController _instance;
        private System.ComponentModel.Container _components;
        private NotifyIcon _notifyIcon;
        public Action ShutDown;

        public static TrayItemController Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new TrayItemController();
                    }
                }

                return _instance;
            }
        }

        private TrayItemController()
        {
            Initialize();
        }

        private void Initialize()
        {
            var iconStream = typeof(TrayItemController).Assembly.GetManifestResourceStream("BlackMesa.PreferenceManagement.Assets.Coffee.ico");
            _components = new System.ComponentModel.Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(iconStream),
                Text = "Kewl",
                Visible = true
            };

            _notifyIcon.ContextMenu = new ContextMenu();


            var j = new MenuItem("Shutdown");
            j.Click += j_Click;
            _notifyIcon.ContextMenu.MenuItems.Add(j);

            var i = new MenuItem("Configure");
            i.Click += i_Click;
            _notifyIcon.ContextMenu.MenuItems.Add(i);
        }

        void i_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
        }

        void j_Click(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
