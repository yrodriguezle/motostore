<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Area extends Model
{

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function country()
  {
    return $this->belongsTo('App\Country');
  }
}
