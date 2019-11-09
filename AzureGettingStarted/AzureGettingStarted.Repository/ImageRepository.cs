using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureGettingStarted.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureGettingStarted.Repository
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly Context _context;
        public ImageRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Image> GetAll()
        {
            return _context.Images.Include(i => i.VisionResult)
                .ThenInclude(v => v.Adult)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Brands)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Categories)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Color)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Description)
                .ThenInclude(d => d.Captions)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Faces)
                .ThenInclude(f => f.FaceRectangle)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.ImageType)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Metadata)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Objects)
                .ThenInclude(o => o.Rectangle)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Tags);
        }

        public async Task<Image> Get(int id)
        {
            return await _context.Images.Include(i => i.VisionResult)
                .ThenInclude(v => v.Adult)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Brands)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Categories)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Color)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Description)
                .ThenInclude(d => d.Captions)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Faces)
                .ThenInclude(f => f.FaceRectangle)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.ImageType)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Metadata)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Objects)
                .ThenInclude(o => o.Rectangle)
                .Include(i => i.VisionResult)
                .ThenInclude(v => v.Tags).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Insert(Image entity)
        {
            var verify = await Get(entity.Id);
            if (verify != null)
                return false;
            try
            {
                _context.Images.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var verify = await Get(id);
            if (verify == null)
                return false;
            try
            {
                _context.Images.Remove(verify);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Image entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
