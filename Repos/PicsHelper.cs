using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public static class PicsHelper
    {
        public static void save(IFormFile file)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
            using (var stream = new FileStream(Path.Combine(path,uniqueFileName), FileMode.Create))
            {
                //    var e = Image.Load(ImageData.OpenReadStream());
                //    e.SaveAsJpeg(path);

                file.CopyTo(stream);
            }
        }
    }
}
