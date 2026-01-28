using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.DTOs;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IFornecedorService  fornecedorService,
                                      IEnderecoRepository  enderecoRepository,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> ObterTodos()
        {
            var fornecedor = _mapper.Map<IEnumerable<FornecedorDto>>(await _fornecedorRepository.ObterTodos());

            return Ok(fornecedor);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorDto>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> Adicionar(FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorDto));

            return CustomResponse(fornecedorDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorDto>> Atualizar(Guid id, FornecedorDto fornecedorDto)
        {
            if (id != fornecedorDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(fornecedorDto);
            }
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorDto));
            
            return CustomResponse(fornecedorDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorDto>> Excluir(Guid id)
        {
            var fornecedorDto = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorDto == null) return NotFound();
            
            await _fornecedorService.Remover(id);
            
            return CustomResponse(fornecedorDto);
        }

        private async Task<ActionResult<FornecedorDto>> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDto>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        private async Task<ActionResult<FornecedorDto>> ObterEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDto>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}