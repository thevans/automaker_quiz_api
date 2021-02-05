using System;
using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomakerQuiz.Application.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IServiceQuestion _servicequestion;

        public QuestionController(IServiceQuestion servicequestion) =>
            _servicequestion = servicequestion;


        [HttpPost]
        public IActionResult Register([FromBody] CreateQuestionModel questionModel)
        {
            try
            {
                var question = _servicequestion.Insert(questionModel);

                return Created($"/api/questions/{question?.Id}", question?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateQuestionModel questionModel)
        {
            try
            {
                var question = _servicequestion.Update(id, questionModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            try
            {
                _servicequestion.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult RecoverAll()
        {
            try
            {
                var questions = _servicequestion.RecoverAll();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Recover([FromRoute] int id)
        {
            try
            {
                var question = _servicequestion.RecoverById(id);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}