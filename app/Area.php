<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Area extends Model
{

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function country()
  {
    return $this->belongsTo(Country::class);
  }
}
