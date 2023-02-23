using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clientes.Commands.UpdateClienteCommand
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }

    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);

            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            }
            else
            {
                record.Nombre = request.Nombre;
                record.Apellido = request.Apellido;
                record.FechaNacimiento = request.FechaNacimiento;
                record.Telefono = request.Telefono;
                record.Email = request.Email;
                record.Direccion = request.Direccion;

                await _repositoryAsync.UpdateAsync(record);

                return new Response<int>(record.Id);
            }
        }
    }
}
