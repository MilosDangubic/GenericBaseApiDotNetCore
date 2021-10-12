using BaseApi.Controllers.Requests;
using BaseApi.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService mailService;
        public EmailController(IEmailService mailService) 
        {
            this.mailService = mailService;
        }

    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm] EmailRequest request)
    {
        try
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
                return BadRequest();
        }         
    }

    }
}
