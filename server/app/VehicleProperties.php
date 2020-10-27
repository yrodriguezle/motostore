<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class VehicleProperties extends Model
{
  protected $table = 'vehicle_properties';

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function vehicles()
  {
    return $this->belongsTo(Vehicle::class);
  }
}
