using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using System.Security.Cryptography;
using System.Text;
using api.Authentication;

namespace api.Services.Entities
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> BuscarTodosUsuario()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuario();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> BuscarPorEmail(string email)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmail(email);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> Login(Login login)
        {
            var usuario = await _usuarioRepositorio.Login(login);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task Adicionar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDTO);
            await _usuarioRepositorio.Adicionar(usuario);
            usuarioDTO.Id = usuario.Id;
        }

        public async Task Atualizar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDTO);
            await _usuarioRepositorio.Atualizar(usuario);
        }

        public async Task Apagar(int id)
        {
            await _usuarioRepositorio.Apagar(id);
        }

        // Método ValidarUsuario
        public async Task<UsuarioDTO> ValidarUsuario(string email, string senha)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmail(email);
            if (usuario == null || !VerificarSenha(senha, usuario.Senha))
            {
                return null;
            }

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        // Método para verificar a senha com hash (exemplo com SHA256)
        private bool VerificarSenha(string senhaInformada, string senhaArmazenada)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaInformada));
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString == senhaArmazenada;
            }
        }
    }
}
