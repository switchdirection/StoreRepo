﻿using Application.Developers.Model;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Developers.Service
{
    /// <summary>
    /// Интерфейс сервиса по работае с разработчиками
    /// </summary>
    public interface IDeveloperService
    {
        /// <summary>
        /// Метод для получения всех разработчиков
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        Task<List<DeveloperEntity>> GetAllDevelopersAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Метод для получения разработчика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<DeveloperEntity> GetDeveloperByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления разработчика
        /// </summary>
        /// <param name="developerName">Имя разработчика</param>
        /// <param name="developerWebsite">Ардес веб-сайта разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddDeveloperAsync(string developerName, string developerWebsite, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения всех разработчиков в виде транспортной модели
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task<List<DeveloperDto>> GetAllDevelopersDtoAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления разработчика
        /// </summary>
        /// <param name="developerId">Идентификатор разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeleteDeveloperAsync(int developerId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования разработчика
        /// </summary>
        /// <param name="model">Модель для редартирования разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> EditDeveloperAsync(EditDeveloperModel model, CancellationToken cancellation);
        /// <summary>
        /// Метод получения разработчика по запросу
        /// </summary>
        /// <param name="request">Запрос на получения разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddDeveloperByRequestAsync(AddDeveloperRequest request, CancellationToken cancellation);

    }
}
