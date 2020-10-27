<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Stock extends Model
{
  protected $table = 'stock';
  
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function vehicles()
  {
    return $this->belongsToMany(Vehicle::class, 'stock_vehicle');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function user()
  {
    return $this->belongsTo(User::class);
  }
}
