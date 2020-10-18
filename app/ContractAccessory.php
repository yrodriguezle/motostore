<?php

namespace App;
use Illuminate\Database\Eloquent\Relations\Pivot;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class ContractAccessory extends Pivot
{
  public function user(): BelongsTo
  {
    return $this->belongsTo(User::class, 'user_id');
  }
}