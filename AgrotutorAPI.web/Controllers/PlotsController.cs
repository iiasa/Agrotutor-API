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
            bool uploadImagesresult = true;
            if (finalPlot.MediaItems.Count > 0)
            {
                 uploadImagesresult = _pictureRepository.UploadImages(finalPlot.MediaItems);
            }

            if (uploadImagesresult)
            {


                await _plotRepository.AddPlotAsync(finalPlot);
                if (! await _plotRepository.SaveAsync())
                    return StatusCode(500, "A problem happend while handling your request");

                var createdPlot = Mapper.Map<PlotDto>(finalPlot);
                return Ok(createdPlot);
            }

            return StatusCode(500, "A problem happend while handling your request");

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