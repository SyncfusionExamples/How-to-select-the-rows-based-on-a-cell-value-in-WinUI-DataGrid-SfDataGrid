using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataGridDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {        
        IPropertyAccessProvider reflector = null;

        public MainWindow()
        {
            this.InitializeComponent();          
        }                      

        private void btnSelectRowClicked(object sender, RoutedEventArgs e)
        {
            if (dataGrid.View != null)
            {
                reflector = dataGrid.View.GetPropertyAccessProvider();                

                if (reflector != null)
                {
                    // Check the DataGrid has rows and columns.
                    if (dataGrid.View.Records != null && dataGrid.Columns != null)
                    {
                        // Clear the previously selected items in SfDataGrid
                        dataGrid.SelectedItems.Clear();

                        // Get the total number of rows in the DataGrid.
                        var totalRowIndex = dataGrid.View.Records.Count;

                        // Get the total number of columns in the DataGrid.
                        var totalColumnIndex = dataGrid.Columns.Count;

                        // Iterate the rows.
                        for (int recordIndex = 0; recordIndex < totalRowIndex; recordIndex++)
                        {
                            // Iterate the columns.
                            for (int colindex = 0; colindex < totalColumnIndex; colindex++)
                            {
                                // Get the record based on recordIndex.
                                var record = this.dataGrid.View.Records[recordIndex];

                                if (record != null)
                                {
                                    // Get the mappingName of the column.
                                    var mappingName = dataGrid.Columns[colindex].MappingName;

                                    if (mappingName != null)
                                    {
                                        //Get the cell value based on mappingName.
                                        var currentCellValue = reflector.GetValue(record.Data, mappingName);

                                        // Check the cell value is equal to "Germany".
                                        if (currentCellValue != null && currentCellValue.ToString() == "Germany")
                                        {
                                            // Get the record entry based on recordIndex that satisfied the condition.
                                            RecordEntry item = dataGrid.View.Records[recordIndex];
                                            
                                            if (item != null && dataGrid.SelectedItems != null)
                                            {                                               
                                                //selected rows should be added here.
                                                dataGrid.SelectedItems.Add(item.Data);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}