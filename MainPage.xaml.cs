using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.ViewManagement;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace FileManager
{

    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SetContent(string content)
        {
            contentBox.Text = content;
        }


        private async void openFile(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".txt");

            StorageFile file = await picker.PickSingleFileAsync();

            try
            {

                if (file != null)
                {
                    //Filen finns, ladda innehåll
                    string newContent = await Windows.Storage.FileIO.ReadTextAsync(file);
                    SetContent(newContent);

                    ApplicationView appView = ApplicationView.GetForCurrentView();
                    appView.Title = file.Name;
                }
            }

            catch (FileNotFoundException)
            {
                //Filen finns inte, gör ingenting
            }

            catch (DriveNotFoundException)
            {
                //Hårddisken kan inte hittas, gör ingenting
            }

            catch (FileLoadException)
            {
                //Filen kunde inte laddas
            }

            catch (PathTooLongException)
            {
                //PATH är för lång
            }

            catch (EndOfStreamException)
            {
                //Programmet försökte läsa förbi en stream
            }

            catch (DirectoryNotFoundException)
            {
                //Mappen kunde inte hittas
            }

        }


        private async void emptyFile(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".txt");

            StorageFile file = await picker.PickSingleFileAsync();

            try
            {

                if (file != null)
                {
                    //Filen finns, tillfoga innehåll
                    await Windows.Storage.FileIO.WriteTextAsync(file, "");

                }
            }

            catch (FileNotFoundException)
            {
                //Filen finns inte, gör ingenting
            }

            catch (DriveNotFoundException)
            {
                //Hårddisken kan inte hittas, gör ingenting
            }

            catch (FileLoadException)
            { 
                //Filen kunde inte laddas
            }

            catch(PathTooLongException)
            {
                //PATH är för lång
            }

            catch(EndOfStreamException)
            {
                //Programmet försökte läsa förbi en stream
            }

            catch(DirectoryNotFoundException)
            {
                //Mappen kunde inte hittas
            }

        }


        private async void appendFile(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".txt");

            StorageFile file = await picker.PickSingleFileAsync();

            try
            {

                if (file != null)
                {
                    //Filen finns, tillfoga innehåll
                    await Windows.Storage.FileIO.AppendTextAsync(file, contentBox.Text);

                }
            }

            catch (FileNotFoundException)
            {
                //Filen finns inte, gör ingenting
            }

            catch (DriveNotFoundException)
            {
                //Hårddisken kan inte hittas, gör ingenting
            }

            catch (FileLoadException)
            {
                //Filen kunde inte laddas
            }

            catch (PathTooLongException)
            {
                //PATH är för lång
            }

            catch (EndOfStreamException)
            {
                //Programmet försökte läsa förbi en stream
            }

            catch (DirectoryNotFoundException)
            {
                //Mappen kunde inte hittas
            }
        }


        private async void saveFile(object sender, RoutedEventArgs e)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.SuggestedFileName = "text.txt";
            picker.FileTypeChoices.Add("Text", new List<string>() { ".txt" });

            StorageFile file = await picker.PickSaveFileAsync();

            try
            {
                if (file != null)
                {
                    //Skriv till fil
                    Windows.Storage.CachedFileManager.DeferUpdates(file);
                    await Windows.Storage.FileIO.WriteTextAsync(file, contentBox.Text);

                }
            }

            catch (FileNotFoundException)
            {
                //Filen finns inte, gör ingenting
            }

            catch (DriveNotFoundException)
            {
                //Hårddisken kan inte hittas, gör ingenting
            }

            catch (FileLoadException)
            {
                //Filen kunde inte laddas
            }

            catch (PathTooLongException)
            {
                //PATH är för lång
            }

            catch (EndOfStreamException)
            {
                //Programmet försökte läsa förbi en stream
            }

            catch (DirectoryNotFoundException)
            {
                //Mappen kunde inte hittas
            }

        }
    }
}
