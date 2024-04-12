using Infrastructure.Context;
using Infrastructure.Dto;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace SiliconAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(DataContext context) : ControllerBase
{

    private readonly DataContext _context = context;

    /// <summary>
    /// create a subscriber
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateSubscriber(SubscribersDto subscribersDto)
    {
        ///creating a sunscriber, checking with modelstate if it's valid
        if (ModelState.IsValid)
        {
            ///save to database
            ///if it doesn't find an an email already it should create one and save to the database 
            if (!await _context.Subscribers.AnyAsync(x => x.Email == subscribersDto.Email))
            {
                try
                {
                    var subscriberEntity = new SubscribersEntity
                    { 
                        Email = subscribersDto.Email,
                        AdvertisingUpdates = subscribersDto.AdvertisingUpdates,
                        DailyNewsletter = subscribersDto.DailyNewsletter,
                        EventUpdates = subscribersDto.EventUpdates,
                        Podcasts = subscribersDto.Podcasts,
                        StartupsWeekly = subscribersDto.StartupsWeekly,
                        WeekInReview = subscribersDto.WeekInReview
                    
                    };
                    
                    _context.Subscribers.Add(subscriberEntity);
                    await _context.SaveChangesAsync();

                    return Created("", null); ///status 201
                }
                catch 
                {
                    return Problem("Failed to create subscription!");
                }
                
            }
            ///if unable to create subscription because of email already exists. 
            return Conflict("Subscriber with the same email already exists.");
        }
       
        ///if not working
        return BadRequest();    
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        ///return subscribers in a list if they exist (id over 0) return, subscribers with ok code 200
        var subscribers = await _context.Subscribers.ToListAsync();
        if (subscribers.Count != 0) 
        {
            return Ok(subscribers);
        }
        ///if no subscribers exists.
        return NotFound();
    }

    /// <summary>
    /// Delete a subscriber
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> UnsubscribeAsync(int id)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        if (subscriber != null) 
        {
            ///remove sunscriber if found, return status code 200 (ok)
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok();

        }

        ///if not found, return status code 404 not found.
        return NotFound();
    }
}
