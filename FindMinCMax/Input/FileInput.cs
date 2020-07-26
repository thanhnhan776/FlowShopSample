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
                LoadEligibility();
                LoadProcessingTimes();
                LoadLagTimes();

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

            InputData.Machines = machines.ClonedInstance();
        }

        private static void LoadEligibility()
        {
            var eligibilitySheet = _wb.GetSheet(FileInputConstants.EligibilitySheet);
            var startCell = _constants.EligibilityCellStart;
            var eligibility = new int[InputData.NumOfStages][][];
            // loop through stages
            for (var i = 0; i < InputData.NumOfStages; ++i)
            {
                eligibility[i] = new int[InputData.NumOfJobs][];
                var rowIndex = startCell.RowIndex + InputData.NumOfJobs * i;
                // loop through jobs
                for (var j = 0; j < InputData.NumOfJobs; ++j)
                {
                    var colIndex = startCell.ColIndex;
                    var machine = eligibilitySheet.GetCellIntValue(rowIndex, colIndex, FileInputConstants.EmptyCellValue);
                    var machines = new List<int>();

                    // read eligibility machines
                    while (machine != FileInputConstants.EmptyCellValue)
                    {
                        machines.Add(machine);
                        machine = eligibilitySheet.GetCellIntValue(rowIndex, ++colIndex,
                            FileInputConstants.EmptyCellValue);
                    }

                    eligibility[i][j] = machines.ToArray();
                    ++rowIndex;
                }
            }

            InputData.Eligibility = eligibility.ClonedInstance();
        }

        private static void LoadProcessingTimes()
        {
            var processingTimesSheet = _wb.GetSheet(FileInputConstants.ProcessingTimesSheet);
            var startCell = _constants.ProcessingTimesCellStart;
            var rowIndex = startCell.RowIndex;
            var colIndex = startCell.ColIndex;
            var processingTimes = new int[InputData.NumOfStages][][];
            for (var i = 0; i < InputData.NumOfStages; ++i)
            {
                var numOfMachines = InputData.Machines[i].Length;
                processingTimes[i] = new int[numOfMachines][];
                for (var l = 0; l < numOfMachines; ++l)
                {
                    processingTimes[i][l] = new int[InputData.NumOfJobs];
                    for (var j = 0; j < InputData.NumOfJobs; ++j)
                    {
                        var processingTime = processingTimesSheet.GetCellIntValue(rowIndex, colIndex);
                        processingTimes[i][l][j] = processingTime;
                        ++rowIndex;
                    }
                }
            }

            InputData.ProcessingTimes = processingTimes.ClonedInstance();
        }
        private static void LoadLagTimes()
        {
            var lagTimesSheet = _wb.GetSheet(FileInputConstants.LagTimesSheet);
            var startCell = _constants.LagTimesCellStart;
            var rowIndex = startCell.RowIndex;
            var colIndex = startCell.ColIndex;
            var lagTimes = new int[InputData.NumOfStages - 1][][]; // last stage does not have lag time
            for (var i = 0; i < InputData.NumOfStages - 1; ++i) 
            {
                var numOfMachines = InputData.Machines[i].Length;
                lagTimes[i] = new int[numOfMachines][];
                for (var l = 0; l < numOfMachines; ++l)
                {
                    lagTimes[i][l] = new int[InputData.NumOfJobs];
                    for (var j = 0; j < InputData.NumOfJobs; ++j)
                    {
                        var lagTime = lagTimesSheet.GetCellIntValue(rowIndex, colIndex);
                        lagTimes[i][l][j] = lagTime;
                        ++rowIndex;
                    }
                }
            }

            InputData.LagTimes = lagTimes.ClonedInstance();
        }
    }
}
