using System.Collections.Generic;
using AgrotutorAPI.Data.Entities;
using AgrotutorAPI.Domain;
using AgrotutorAPI.web.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult Plots()
        {
            var res = JsonConvert.SerializeObject(new PlotDto());
            var plotsList = _plotRepository.GetPlots();
            var result = Mapper.Map<IEnumerable<PlotDto>>(plotsList);
            return Ok(result);
        }

        // GET api/Plots/5
        [HttpGet("{id}")]
        public ActionResult<PlotDto> GetPlotsById(int plotId)
        {
            var plotRes = _plotRepository.GetPlotById(plotId);
            if (plotRes == null) return NotFound();
       
            var result = Mapper.Map<PlotDto>(plotRes);
            return Ok(result);
        }

        // POST api/Plots
        [HttpPost]
        [Route("CreatePlot")]
        public ActionResult CreatePlot([FromBody] PlotDto plotDto)
        {

          var result=  _pictureRepository.UploadImages(plotDto.MediaItems);
            if (result)
            {
                var finalPlot = Mapper.Map<Plot>(plotDto);

                _plotRepository.AddPlot(finalPlot);
                if (!_plotRepository.Save())
                    return StatusCode(500, "A problem happend while handling your request");

                var createdPlot = Mapper.Map<PlotDto>(finalPlot);
                return CreatedAtRoute("GetPlotsById", new {plotId = createdPlot.Id}, createdPlot);
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