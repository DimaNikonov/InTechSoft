using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTaskWebApi.API.Entities;
using TestTaskWebApi.DAL.Entitties;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqQuestionController : ControllerBase
    {
        private readonly IUnitOfWorks unitOfWorks;

        private readonly IMapper mapper;

        public FaqQuestionController(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }

        // GET: api/FaqQuestion
        [HttpGet]
        public ActionResult<IEnumerable<FaqQuestionViewModel>> Get()
        {
            var faqQuestions = this.unitOfWorks.FaqQuestionRepositiry.GetAll();

            return this.Ok(this.mapper.Map<IEnumerable<FaqQuestion>, IEnumerable<FaqQuestionViewModel>>(faqQuestions));
        }

        // GET: api/FaqQuestion/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<FaqQuestionViewModel> Get(int id)
        {
            var faqQuestion = this.unitOfWorks.FaqQuestionRepositiry.Get(id);

            if (faqQuestion == null)
            {
                return this.NotFound();
            }

            return this.Ok(this.mapper.Map<FaqQuestion, FaqQuestionViewModel>(faqQuestion));
        }

        // POST: api/FaqQuestion
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateFaqQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                return this.BadRequest();
            }

            var faqQuestion = this.mapper.Map<CreateFaqQuestionViewModel, FaqQuestion>(viewModel);

            this.unitOfWorks.FaqQuestionRepositiry.Create(faqQuestion);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();
        }

        // PUT: api/FaqQuestion/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateFaqQuestionViewModel viewModel)
        {
            var faqQuestion = this.unitOfWorks.FaqQuestionRepositiry.Get(id);

            if (faqQuestion == null)
            {
                return this.NotFound();
            }

            this.mapper.Map<CreateFaqQuestionViewModel, FaqQuestion>(viewModel, faqQuestion);
            this.unitOfWorks.FaqQuestionRepositiry.Update(faqQuestion);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();
        }

        // DELETE: api/FaqQuestion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var faqQustion = this.unitOfWorks.FaqQuestionRepositiry.Get(id);

            if (faqQustion == null)
            {
                return this.NotFound();
            }
            this.unitOfWorks.FaqQuestionRepositiry.Delete(faqQustion);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();
        }
    }
}