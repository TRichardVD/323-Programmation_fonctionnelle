using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;


namespace MarchéExo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string XLSX_FILE_PATH = "C:\\Users\\pw57drg\\Documents\\GitHub\\323-Programmation_fonctionnelle\\exos\\marché\\Place du marché.xlsx";
            int NbrOfPeachSeller = 0;

            DataTable dt = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet = null;

            using (var stream = new FileStream(XLSX_FILE_PATH, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                ISheet positionsSheet = xssWorkbook.GetSheetAt(0);
                ISheet productsSheet = xssWorkbook.GetSheetAt(1);



                // Step 1

                int productCount = productsSheet.LastRowNum;

                IRow headerRow = productsSheet.GetRow(0);

                int produterColumn = headerRow.First(cell => cell.ToString() == "Producteur").Address.Column;
                int productColumn = headerRow.First(cell => cell.ToString() == "Produit").Address.Column;

                List<IRow> rowsOfPeachesProducter = new List<IRow>();

                for (int i = 1; i < productCount -1; i++)
                {
                    IRow row = productsSheet.GetRow(i);
                    if (row != null && row.GetCell(productColumn).StringCellValue == "Pêches")
                    {
                        rowsOfPeachesProducter.Add(row);
                    }
                }

                NbrOfPeachSeller = rowsOfPeachesProducter.Count;
                Console.WriteLine($"Il y a {NbrOfPeachSeller} vendeurs de pêches");


                // Step 2

                int quantityColumn = headerRow.First(cell => cell.ToString() == "Quantité").Address.Column;
                int positionColumn = headerRow.First(cell => cell.ToString() == "Emplacement").Address.Column;
                int unityColumn = headerRow.First(cell => cell.ToString() == "Unité").Address.Column;


                List<IRow> rowsOfWatermelonProducter = new List<IRow>();

                for (int i = 1; i < productCount - 1; i++)
                {
                    IRow row = productsSheet.GetRow(i);
                    if (row != null && row.GetCell(productColumn).StringCellValue == "Pastèques")
                    {
                        rowsOfWatermelonProducter.Add(row);
                    }
                }

                IRow bestWaterMelonProducter = rowsOfWatermelonProducter.OrderByDescending(row => row.GetCell(quantityColumn).NumericCellValue).First();

                Console.WriteLine($"C'est {bestWaterMelonProducter.GetCell(produterColumn).StringCellValue} qui à le plus de pastèques (stand {bestWaterMelonProducter.GetCell(positionColumn).NumericCellValue}, {bestWaterMelonProducter.GetCell(quantityColumn).NumericCellValue} {bestWaterMelonProducter.GetCell(unityColumn).StringCellValue})");




            }




            
           
        }
    }
}