using System.Collections.Generic;
using System.Threading.Tasks;
using AgrotutorAPI.Data.Contract;
using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgrotutorAPI.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotsController : ControllerBase
    {
        private readonly IPlotRepository _plotRepository;
        private readonly IPictureRepository _pictureRepository;
        public PlotsController(IPlotRepository plotRepository, IPictureRepository pictureRepository)
        {
            _plotRepository = plotRepository;
            _pictureRepository = pictureRepository;

        }

        // GET api/Plots
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Plots()
        {
            var plotsList =await _plotRepository.GetPlotsAsync();
            var result = Mapper.Map<IEnumerable<PlotDto>>(plotsList);
            return Ok(result);
        }

        // GET api/Plots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlotsById(int plotId)
        {
            var plotRes = await _plotRepository.GetPlotByIdAsync(plotId);
            if (plotRes == null) return NotFound();
       
            var result = Mapper.Map<PlotDto>(plotRes);
            return Ok(result);
        }

        // POST api/Plots/CreatePlot
        [HttpPost]
        [Route("CreatePlot")]
        public async Task<IActionResult> CreatePlot([FromBody] PlotDto plotDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var finalPlot = Mapper.Map<Plot>(plotDto);

            var plotToUpdate = await _plotRepository.GetPlotByMobileIdAndLocation(finalPlot.MobileId, finalPlot.Position);
            if (plotToUpdate != null)
            {
                // update plot
                
                await _plotRepository.PrepareForUpdate(plotToUpdate);
                finalPlot = Mapper.Map(plotDto, plotToUpdate);

                var uploadImagesresult2 = UploadImagesresult(finalPlot);

                if (uploadImagesresult2)
                {
                    _plotRepository.UpdatePlot(finalPlot);

                    if (!await _plotRepository.SaveAsync())
                        return StatusCode(500, "A problem happend while handling your request");

                    return Ok();
                }
            }

            var uploadImagesresult = UploadImagesresult(finalPlot);

            if (uploadImagesresult)
            {
                finalPlot.Id = 0; // set Id to zero to successfully update Record.
                await _plotRepository.AddPlotAsync(finalPlot);
                if (! await _plotRepository.SaveAsync())
                    return StatusCode(500, "A problem happend while handling your request");

                return Ok();
            }

            return StatusCode(500, "A problem happend while handling your request");

        }

        private bool UploadImagesresult(Plot finalPlot)
        {
            bool uploadImagesresult = true;
            if (finalPlot.MediaItems.Count > 0)
            {
                uploadImagesresult = _pictureRepository.UploadImages(finalPlot.MediaItems);
            }

            return uploadImagesresult;
        }

        // PUT api/Plots/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PlotDto plotDto)
        {
        }

        // DELETE api/Plots/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}