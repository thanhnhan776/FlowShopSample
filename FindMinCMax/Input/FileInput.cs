using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindMinCMax.Utils;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FindMinCMax.Input
{
    public class FileInput
    {
        public static string FilePath { get; set; } = "FlowShopInputData.xlsx";
        private static XSSFWorkbook _wb;
        private static FileInputConstants _constants;

        /// <summary>
        /// load input data from file
        /// </summary>
        /// <returns>error message, if any</returns>
        public static string LoadInputData()
        {
            _constants = new FileInputConstants();
            try
            {
                var fs = new FileStream(FilePath, FileMode.Open);
                _wb = new XSSFWorkbook(fs);

                LoadStageAndJob();
                LoadMachines();

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private static void LoadStageAndJob()
        {
            var stageAndJobSheet = _wb.GetSheet(FileInputConstants.StageAndJobSheet);
            var numberOfStages = stageAndJobSheet.GetCellIntValue(_constants.NumOfStagesCellIndex);
            var numberOfJobs = stageAndJobSheet.GetCellIntValue(_constants.NumOfJobsCellIndex);

            InputData.NumOfStages = numberOfStages;
            InputData.NumOfJobs = numberOfJobs;
        }
        private static void LoadMachines()
        {
            var machinesSheet = _wb.GetSheet(FileInputConstants.MachinesSheet);
            var machineCellIndex = _constants.NumOfMachinesCellStart;
            var machines = new int[InputData.NumOfStages][];
            for (var i = 0; i < machines.Length; ++i)
            {
                var numberOfMachines = machinesSheet.GetCellIntValue(machineCellIndex);
                machineCellIndex.Next();

                machines[i] = new int[numberOfMachines];
                for (var l = 0; l < numberOfMachines; ++l)
                {
                    machines[i][l] = l + 1;
                }
            }

            InputData.Machines = machines;
        }
    }
}
