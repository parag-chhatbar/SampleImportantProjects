using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CustomGallery.Interfaces
{
	public interface IPermissionService
	{
		Task<PermissionStatus> GetStoragePermission();
	}
}

