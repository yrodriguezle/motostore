<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Brand extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function vehicles()
  {
    return $this->hasMany(Vehicle::class);
  }

  public function estimate_acquired_vehicles()
  {
    return $this->hasOne('App\EstimateAcquiredVehicle');
  }
}
