<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Estimate extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function user()
  {
    return $this->belongsTo(User::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function customer()
  {
    return $this->belongsTo(Customer::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function vehicle()
  {
    return $this->belongsTo(Vehicle::class);
  }

  // public function estimate_acquired_vehicles()
  // {
  //   return $this->hasMany('App\EstimateAcquiredVehicle');
  // }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function accessories()
  {
    return $this->belongsToMany(Accessory::class, 'estimates_accessories');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function services()
  {
    return $this->belongsToMany(Service::class, 'estimates_services');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function payments()
  {
    return $this->belongsToMany(Payment::class, 'payments_estimates');
  }
}
