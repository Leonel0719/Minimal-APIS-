using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using LADCH.DTOs.CustomerDTOs;
using LADCH.AppWebMVC.Controllers;

namespace LADCH.AppWebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClientLADCHAPI;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientLADCHAPI = httpClientFactory.CreateClient("LADCHAPI");
        }

        public async Task<IActionResult> Index(SearchQueryCustomerDTO queryCustomerDTO, int CountRow = 0)
        {
            if (queryCustomerDTO.SendRowCount == 0)
                queryCustomerDTO.SendRowCount = 2;
            if (queryCustomerDTO.Take == 0)
                queryCustomerDTO.Take = 10;

            var result = new SearchResultCustomerDTO();

            var response = await _httpClientLADCHAPI.PostAsJsonAsync("/customer/search", queryCustomerDTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultCustomerDTO>();

            result = result != null ? result : new SearchResultCustomerDTO();

            if (result.CountRow == 0 && queryCustomerDTO.SendRowCount == 1)
                result.CountRow = CountRow;

            ViewBag.CountRow = result.CountRow;
            queryCustomerDTO.SendRowCount = 0;
            ViewBag.SearchQuery = queryCustomerDTO;

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultCustomerDTO();

            var response = await _httpClientLADCHAPI.GetAsync("/customer/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();

            return View(result ?? new GetIdResultCustomerDTO());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerDTO createDTO)
        {
            try
            {
                var response = await _httpClientLADCHAPI.PostAsJsonAsync("/customer", createDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al intentar guardar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultCustomerDTO();
            var response = await _httpClientLADCHAPI.GetAsync("/customer/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();

            return View(new EditCustomerDTO(result ?? new GetIdResultCustomerDTO()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCustomerDTO editDTO)
        {
            try
            {
                var response = await _httpClientLADCHAPI.PutAsJsonAsync("/customer", editDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al intentar editar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultCustomerDTO();
            var response = await _httpClientLADCHAPI.GetAsync("/customer/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();

            return View(result ?? new GetIdResultCustomerDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultCustomerDTO getIdResultDTO)
        {
            try
            {
                var response = await _httpClientLADCHAPI.DeleteAsync("/customer/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al intentar editar el registro";
                return View(getIdResultDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(getIdResultDTO);
            }
        }
    }
}
