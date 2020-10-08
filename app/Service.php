<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Service extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function estimates()
  {
    return $this->belongsToMany(Estimate::class, 'estimates_services');
  }

  // public function contracts()
  // {
  //   return $this->belongsToMany('App\Contract', 'contracts_services');
  // }
}
