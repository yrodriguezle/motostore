<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Phone extends Model
{
  public $timestamps = false;
  
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function customers()
  {
    return $this->belongsToMany(Customer::class, 'customers_phones');
  }
}