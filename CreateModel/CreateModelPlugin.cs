using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateModel
{

    [TransactionAttribute(TransactionMode.Manual)]
    public class CreateModelPlugin : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;





            Transaction transaction = new Transaction(doc, "Построение стены");
            transaction.Start();
            List<Wall> newWalls = WallBuilder.CreateWallsFromRectangle(doc, "Уровень 1", "Уровень 2", 10000, 5000);


            transaction.Commit();




            return Result.Succeeded;
        }
    }
}
