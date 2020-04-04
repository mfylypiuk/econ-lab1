using econ_lab1.Interfaces;
using econ_lab1.Services;
using IOData;
using System;
using System.Collections.Generic;
using System.Text;

namespace econ_lab1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private IFileService fileService;
        private IDialogService dialogService;

        private InputData inputData;
        private OutputData outputData;

        private CommandService openInputDataFileCommand;
        private CommandService saveOutputDataToFileCommand;
        private CommandService calculateCommand;

        public Dictionary<string, string> InputDataViewable { get; set; }
        public Dictionary<string, string> OutputDataViewable { get; set; }

        public CommandService OpenInputDataFileCommand
        {
            get
            {
                if (openInputDataFileCommand == null)
                {
                    openInputDataFileCommand = new CommandService(ExecuteOpenInputDataFileCommand);
                }

                return openInputDataFileCommand;
            }
        }

        public CommandService SaveOutputDataToFileCommand
        {
            get
            {
                if (saveOutputDataToFileCommand == null)
                {
                    saveOutputDataToFileCommand = new CommandService(ExecuteSaveOutputDataToFileCommand, CanExecuteSaveOutputDataToFileCommand);
                }

                return saveOutputDataToFileCommand;
            }
        }

        public CommandService CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new CommandService(ExecuteCalculateCommand, CanExecuteCalculateCommand);
                }

                return calculateCommand;
            }
        }

        

        public MainWindowViewModel()
        {
            fileService = new IOFileService();
            dialogService = new DialogService();
        }

        private void ExecuteOpenInputDataFileCommand(object obj)
        {
            try
            {
                if (dialogService.OpenFileDialog())
                {
                    inputData = fileService.Open(dialogService.FilePath);
                    InputDataViewable = inputData.ToViewableDictionary();
                    OnPropertyChanged(nameof(InputDataViewable));
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

        private void ExecuteSaveOutputDataToFileCommand(object obj)
        {
            try
            {
                if (dialogService.SaveFileDialog() == true)
                {
                    fileService.Save(dialogService.FilePath, outputData);
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

        private bool CanExecuteSaveOutputDataToFileCommand(object arg)
        {
            return inputData != null;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            ComplexityAndDevelopmentTimeCalculator.CommonCalculator complexityAndDevelopmentTimeCalculator =
                new ComplexityAndDevelopmentTimeCalculator.CommonCalculator(inputData.TypeOfTask, inputData.SoftwareNoveltyLevel,
                    inputData.SoftwareComplexityLevel, inputData.ProgrammingLanguageLevel, inputData.TaskDescriptionPrepareTime,
                    inputData.ProgrammerExperience, inputData.DocumentationTime);

            complexityAndDevelopmentTimeCalculator.Calculate();

            outputData = new OutputData();
            outputData.ComplexityData = complexityAndDevelopmentTimeCalculator.ComplexityData;
            outputData.DevelopmentTimeData = complexityAndDevelopmentTimeCalculator.DevelopmentTimeData;

            OutputDataViewable = outputData.ToViewableDictionary();
            OnPropertyChanged(nameof(OutputDataViewable));
        }

        private bool CanExecuteCalculateCommand(object arg)
        {
            return inputData != null;
        }
    }
}
