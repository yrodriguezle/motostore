<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class AcquiredVehicle extends Model
{
  protected $table = 'acquired_vehicles';

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function vehicle()
  {
    return $this->belongsTo(Vehicle::class);
  }
}
