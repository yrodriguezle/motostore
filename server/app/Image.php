<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Image extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function vehicles()
  {
    return $this->belongsTo(Vehicle::class);
  }
}