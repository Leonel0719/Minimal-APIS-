using LADCH.DTOs.CustomerDTOs;

namespace LADCH.AppWebBlazor.Data
{
    public class CustomerService
    {
        readonly HttpClient _httpClientLADCHAPI;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientLADCHAPI = httpClientFactory.CreateClient("LADCHAPI");
        }

        public async Task<SearchResultCustomerDTO> Search(SearchQueryCustomerDTO queryCustomerDTO)
        {
            var response = await _httpClientLADCHAPI.PostAsJsonAsync("/customer/search", queryCustomerDTO);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultCustomerDTO>();
                return result ?? new SearchResultCustomerDTO();
            }
            return new SearchResultCustomerDTO();
        }

        public async Task<GetIdResultCustomerDTO> GetById(int id)
        {
            var response = await _httpClientLADCHAPI.GetAsync("/customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                return result ?? new GetIdResultCustomerDTO();
            }
            return new GetIdResultCustomerDTO();
        }

        public async Task<int> Create(CreateCustomerDTO createDTO)
        {
            int result = 0;
            var response = await _httpClientLADCHAPI.PostAsJsonAsync("/customer", createDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        public async Task<int> Edit(EditCustomerDTO editDTO)
        {
            int result = 0;
            var response = await _httpClientLADCHAPI.PutAsJsonAsync("/customer", editDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientLADCHAPI.DeleteAsync("/customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}
