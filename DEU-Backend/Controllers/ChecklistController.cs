using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Services;
using DEU_Lib.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController(ChecklistService checklistService, IMapper mapper) : ControllerBase
    {
    }
}