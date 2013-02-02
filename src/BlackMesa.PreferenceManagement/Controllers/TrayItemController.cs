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
            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
        }

        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _notifyIcon.ContextMenu = new ContextMenu();
            _notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("blabla"));
        }
    }
}
