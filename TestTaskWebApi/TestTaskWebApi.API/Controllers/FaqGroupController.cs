using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskWebApi.API.Entities;
using TestTaskWebApi.DAL.Entitties;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqGroupController : Controller
    {
        private readonly IUnitOfWorks unitOfWorks;

        private readonly IMapper mapper;

        public FaqGroupController(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }

        // GET api/FaqGroup
        [HttpGet]
        public ActionResult<IEnumerable<FaqGroupViewModel>> Get()
        {
            var faqGroups = this.unitOfWorks.FaqGroupRepository.GetAll();

            return this.Ok(this.mapper.Map<IEnumerable<FaqGroup>, IEnumerable<FaqGroupViewModel>>(faqGroups));
        }

        // GET api/FaqGroup/5
        [HttpGet("{id}")]
        public ActionResult<FaqGroupViewModel> Get(int id)
        {

            var faqGroup = this.unitOfWorks.FaqGroupRepository.Get(id);

            if (faqGroup == null)
            {
                return this.NotFound();
            }

            return this.Ok(this.mapper.Map<FaqGroup, FaqGroupViewModel>(faqGroup));
        }

        // POST api/FaqGroup
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateFaqGroupViewModel viewModel)
        {
            if (viewModel == null)
            {
                return this.BadRequest();
            }

            var faqGroup = this.mapper.Map<CreateFaqGroupViewModel, FaqGroup>(viewModel);
            this.unitOfWorks.FaqGroupRepository.Create(faqGroup);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();
        }

        // PUT api/FaqGroup/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateFaqGroupViewModel viewModel)
        {
            var faqGroup = this.unitOfWorks.FaqGroupRepository.Get(id);

            if (faqGroup == null)
            {
                return this.NotFound();
            }

            this.mapper.Map<CreateFaqGroupViewModel, FaqGroup>(viewModel, faqGroup);
            this.unitOfWorks.FaqGroupRepository.Update(faqGroup);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();

        }

        // DELETE api/FaqGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var faqGroup = this.unitOfWorks.FaqGroupRepository.Get(id);

            if (faqGroup == null)
            {
                return this.NotFound();
            }
            this.unitOfWorks.FaqGroupRepository.Delete(faqGroup);
            await this.unitOfWorks.SaveAsync();
            return this.Ok();
        }
    }
}
