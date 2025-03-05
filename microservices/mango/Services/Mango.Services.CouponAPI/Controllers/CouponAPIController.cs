using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
            
        }

        [HttpGet]
        public ResponseDto Get(){
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                // throw;
            }
             return _response;

        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id){
            try
            {
                Coupon obj = _db.Coupons
                .First(coupon=>coupon.CouponId==id);
                // _mapper.Map<CouponDto> , converts the coupon to couponDto and return sCouponDto
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                 _response.IsSuccess = false;
                _response.Message = ex.Message;                // throw;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(coupon=> coupon.CouponCode.ToLower()==code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                
                _response.IsSuccess = false;
                _response.Message = ex.Message;  
            }
            return _response;
        }
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto){

            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message= ex.Message;
            }
            return _response;

        }

        [HttpPut]
        public ResponseDto Put(CouponDto couponDto){

            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message= ex.Message;
            }
            return _response;


        }
        [HttpDelete]
        public ResponseDto Delete(int id){
            try
            {
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

            }
            catch (System.Exception ex)
            {
                
                _response.IsSuccess = false;
                _response.Message= ex.Message;
            }
            return _response;
        }
    }
}
