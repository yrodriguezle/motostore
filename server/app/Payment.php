<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Payment extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function estimates()
  {
    return $this->belongsToMany(Estimate::class, 'payments_estimates');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function contracts()
  {
    return $this->belongsToMany(Contract::class, 'payments_estimates');
  }
}
