using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;

namespace Tdmts.FileSystem
{
    public class FileSystem
    {
        private static FileSystem _instance;

        private FileSystem() { }

        public static FileSystem getInstance()
        {
            if (_instance == null)
            {
                _instance = new FileSystem();
            }
            return _instance;
        }

        public async Task<StorageFolder> GetStorageFolder(string fileTypeFilter)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add(fileTypeFilter);
            StorageFolder storageFolder = await folderPicker.PickSingleFolderAsync();
            StorageApplicationPermissions.FutureAccessList.Add(storageFolder);
            return storageFolder;
        }

        public async Task<StorageFile> GetStorageFile(string extension)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(extension);
            StorageFile storageFile = await filePicker.PickSingleFileAsync();
            StorageApplicationPermissions.FutureAccessList.Add(storageFile);
            return storageFile;
        }
    }
}
