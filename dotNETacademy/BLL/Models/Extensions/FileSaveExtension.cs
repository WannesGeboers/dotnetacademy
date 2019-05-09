﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace dotNETacademy.BLL.Models.Extensions {
public static class FileSaveExtension
{
    public static async Task SaveAsAsync(this IFormFile formFile, string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }
    }

    public static void SaveAs(this IFormFile formFile, string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            formFile.CopyTo(stream);
        }
    }

    }
}