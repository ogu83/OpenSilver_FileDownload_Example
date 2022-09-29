using System.Windows;
using System.Windows.Controls;

namespace OpenSilver_FileDownload_Example
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            // Enter construction logic here...
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await OpenSilver.Interop.LoadJavaScriptFile("ms-appx:///OpenSilver_FileDownload_Example/js/FileSaver.min.js");
        }

        public void SaveTextToFile(string text, string filename)
        {

            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(filename))
            {
                OpenSilver.Interop.ExecuteJavaScript(@"
                    var blob = new Blob([$0], { type: ""text/plain;charset=utf-8""});
                    saveAs(blob, $1)", text, filename);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var content = "File Text Example Content. lorem ipsum. lorem ipsum...";
            var fileName = "OpenSilverFile.txt";

            SaveTextToFile(content, fileName);
        }
    }
}