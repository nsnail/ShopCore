using ShopCore.Application.Services;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.SysComponent.Application.Services.Sys;

/// <inheritdoc cref="IFileService" />
public sealed class FileService : ServiceBase<IFileService>, IFileService
{
    private readonly MinioHelper   _minioHelper;
    private readonly UploadOptions _uploadOptions;

    /// <summary>
    ///     Initializes a new instance of the <see cref="FileService" /> class.
    /// </summary>
    public FileService(IOptions<UploadOptions> uploadOptions, MinioHelper minioHelper) //
    {
        _minioHelper   = minioHelper;
        _uploadOptions = uploadOptions.Value;
    }

    /// <summary>
    ///     文件上传
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">文件不能为空</exception>
    /// <exception cref="ShopCoreInvalidOperationException">允许上传的文件格式</exception>
    /// <exception cref="ShopCoreInvalidOperationException">允许的文件大小</exception>
    public async Task<string> UploadAsync(IFormFile file)
    {
        if (file is null || file.Length < 1) {
            throw new ShopCoreInvalidOperationException($"{Ln.文件} {Ln.不能为空}");
        }

        if (!_uploadOptions.ContentTypes.Contains(file.ContentType)) {
            throw new ShopCoreInvalidOperationException(string.Format( //
                                                            CultureInfo.InvariantCulture, Ln.允许上传的文件格式
                                                          , string.Join(",", _uploadOptions.ContentTypes)));
        }

        if (file.Length > _uploadOptions.MaxSize) {
            throw new ShopCoreInvalidOperationException(string.Format( //
                                                            CultureInfo.InvariantCulture, Ln.允许的文件大小, _uploadOptions.MaxSize));
        }

        var             fileName   = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var             objectName = $"{UserToken.Id}/{fileName}";
        await using var fs         = file.OpenReadStream();
        return await _minioHelper.UploadAsync(objectName, fs, file.ContentType, file.Length);
    }
}