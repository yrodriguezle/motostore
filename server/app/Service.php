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

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function contracts()
  {
    return $this->belongsToMany(Contract::class, 'contracts_services');
  }
}
